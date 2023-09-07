using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.DTOS;
using API.DTOS.ROLDTO;
using API.Helpers;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;


public class UserService :IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<Usuario> _passwordHasher;



    public Rol RolPredeterminado { get; private set; }

    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt,IPasswordHasher<Usuario> passwordHasher )
    {
        _jwt = jwt.Value;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {    
        
    var usuario = new Usuario
       {
           Email = registerDto.Email,
           Username = registerDto.Username,
          

        
       };

       usuario.Password = _passwordHasher.HashPassword(usuario, registerDto.Password);//Me permite hashear la contraseña dada oir el usuario a la hora de registrarse y pasarselo al objeto usuario que se encargara de tomarla para mas adelante ser guardado en la base de datos como hash
       var usuarioExiste = _unitOfWork.Usuarios
                                      .Find(u => u.Username.ToLower() == registerDto.Username.ToLower()).FirstOrDefault();
        if(usuarioExiste == null)
        {
            var rolPredeterminado = _unitOfWork.Roles   
                                               .Find(u => u.TipoRol == Autorizacion.rol_predeterminado.ToString())
                                               .First();


            try
            {
                usuario.Roles.Add(rolPredeterminado);
                
                _unitOfWork.Usuarios.Add(usuario);
                await _unitOfWork.SaveChanges();

             return $"El usuario  {registerDto.Username} ha sido registrado exitosamente";

            }
            catch(Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
         else
        {
            return $"El usuario con {registerDto.Username} ya se encuentra registrado.";
        }

    }







    public async  Task<DatosUsuarioDto> GetTokenAsync(LoginDto loginDto)
    {

        DatosUsuarioDto datosUsuarioDto = new DatosUsuarioDto();
        var usuario = await _unitOfWork.Usuarios.GetByUserAsync(loginDto.Username);
       
        if(usuario == null)
        {
            datosUsuarioDto.EstaAutenticado = false;
            datosUsuarioDto.Mensaje =$"No existe ningun usuario con el username {loginDto.Username}";
            return datosUsuarioDto;
        }

        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, loginDto.Password);
        if(result == PasswordVerificationResult.Success)
        {
                datosUsuarioDto.Mensaje ="Login Exitoso";
                datosUsuarioDto.EstaAutenticado = true;
                JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
                datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                datosUsuarioDto.Username = usuario.Username;
                datosUsuarioDto.Email = usuario.Email;
                datosUsuarioDto.Roles = usuario.Roles.Select(x => x.TipoRol).ToList();

                return datosUsuarioDto;
                
        }

        datosUsuarioDto.EstaAutenticado = false;
        datosUsuarioDto.Mensaje =$"Credenciales incorrectas para el usuario {usuario.Username}";
       return datosUsuarioDto;
       
    }

    public async   Task<string> AddRoleAsync(AddRolDto addRolDto)
    {

        var usuario = await _unitOfWork.Usuarios.GetByUserAsync(addRolDto.Username);

        if(usuario == null)
        {
            return $"No existe algún usuario registrado con la cuenta {addRolDto.Username}.";
        }

        var resultado = _passwordHasher.VerifyHashedPassword(usuario,usuario.Password, addRolDto.Password);
        if(resultado == PasswordVerificationResult.Success)
        {
            var rolExiste = _unitOfWork.Roles.Find(r => r.TipoRol.ToLower() == addRolDto.Rol.ToLower()).//Aca me dice si existe este registro en la base de datos
                                                FirstOrDefault();
            if(rolExiste != null)
            {
                    var usuarioTieneRol = usuario.Roles.Any( r => r.RolId == rolExiste.RolId);//Aca me dice si el usario ya tenia dicho rol

                    if (usuarioTieneRol == false)
                    {
                        usuario.Roles.Add(rolExiste);
                        _unitOfWork.Usuarios.Update(usuario);
                        await _unitOfWork.SaveChanges();
                    }
                    return $"Rol {addRolDto.Rol} agregado a la cuenta {addRolDto.Username} de forma exitosa";
            }
            return $"Rol {addRolDto.Rol} no encontrado";
        }
        return $"Credenciales incorrectas para el usuario {addRolDto.Username}";





    }


    private JwtSecurityToken CreateJwtToken(Usuario usuario)
    {
        var roles = usuario.Roles;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.TipoRol));
        }
        var claims = new[]
        {
                                new Claim(JwtRegisteredClaimNames.Sub, usuario.Username),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                                new Claim("uid", usuario.UsuarioId.ToString())
                        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        Console.WriteLine("", symmetricSecurityKey);
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    } 







}