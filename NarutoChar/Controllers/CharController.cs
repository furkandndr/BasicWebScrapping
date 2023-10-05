using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.AspNetCore.Mvc;

namespace NarutoChar.Controllers;

[ApiController]
[Route("[controller]")]
public class CharController : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> Get()
    {   
        var link = "https://www.animecharactersdatabase.com/allchars.php?id=100053";
        HtmlWeb site = new HtmlWeb();
        HtmlDocument html = site.Load(link);

        IList<HtmlNode> nodes = html.QuerySelectorAll("div#mainframe1.outframe").QuerySelectorAll("ul.flexcontainer.zero li.flexitem.pad");
        
        
        ;

        var data = nodes.Select((node)=>{
            return new {
                name = node.QuerySelector("p.pad.bo1 a").InnerText
            };
        });
        


        return Ok(data);
       
    }
}
