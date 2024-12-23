using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.DTO.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace BelvedereFood.BLL.Helpers;

public class UserAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserSessionService _userSessionService;

    public UserAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IUserSessionService userSessionService
        ) : base(options, logger, encoder)
    {
        _userSessionService = userSessionService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string token = null;

        token = Request.Headers["Authorization"].ToString();

        if (string.IsNullOrEmpty(token))
        {
            return AuthenticateResult.Fail("Authorization not provided");
        }

        if (!Request.Headers.TryGetValue("Authorization", out var authorizationHeaderValues) && token is null)
        {
            return AuthenticateResult.NoResult();
        }

        token ??= authorizationHeaderValues.FirstOrDefault();

        if (string.IsNullOrEmpty(token))
        {
            return AuthenticateResult.NoResult();
        }

        UserDto user = await _userSessionService.GetByToken(token);

        if (user is null)
        {
            return AuthenticateResult.Fail("Invalid token");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, string.Concat(user.Name))
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}