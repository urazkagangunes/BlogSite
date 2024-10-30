using Core.Tokens.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controller;

public class CustomBaseController(DecoderService _decoderService) : ControllerBase
{
    protected string GetUser()
    {
        return _decoderService.GetUserId();
    }
}
