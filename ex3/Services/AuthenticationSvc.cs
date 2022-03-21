using System.Text;
using System.Text.Json;
using Exceptions;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace Services;

/// <summary>
/// Data type representing the user's security claims according to JWT convention.
/// </summary>
class UserClaims
{
    /// <summary>
    /// Who the user is, ie. the "subject" of the JWT.
    /// </summary>
    public string sub { get; set; } = "";

    public UserClaims(string sub)
    {
        this.sub = sub;
    }
}
/// <summary>
/// Concrete implementor of the JWT authentication interface.
/// </summary>
public class AuthenticationSvc : IAuthenticationSvc
{

    private readonly byte[] JwtKey = Encoding.UTF8.GetBytes("example_key_lol_dont_use_in_prod");
    private IJwtDecoder decoder = new JwtDecoder(new JsonNetSerializer(), new JwtBase64UrlEncoder());
    private IJwtEncoder encoder = new JwtEncoder(new HMACSHA256Algorithm(), new JsonNetSerializer(), new JwtBase64UrlEncoder());

    public string GetJwtForUsername(string username)
    {
        return encoder.Encode(new UserClaims(username), JwtKey);
    }

    public string? TryGetUsernameFromJwt(HttpContext ctx)
    {
        var values = ctx.Request.Headers["Authorization"];
        if (!values.Any())
        {
            return null;
        }
        var jwt = values.First();
        if (jwt == null)
        {
            return null;
        }
        jwt = jwt.Split(":").Last()?.Split(" ").Last();
        if (jwt == null)
        {
            return null;
        }
        var userDataJson = decoder.Decode(jwt);
        var claims = JsonSerializer.Deserialize<UserClaims>(userDataJson);
        if (claims == null)
        {
            return null;
        }
        return claims.sub;
    }

    public string GetUsernameFromJwt(HttpContext ctx)
    {
        var username = TryGetUsernameFromJwt(ctx);
        if (username == null)
        {
            throw new UnauthorizedException();
        }
        else
        {
            return username;
        }
    }
}
