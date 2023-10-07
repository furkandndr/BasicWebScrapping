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
    

        var data = nodes.Select((node)=>
        {
            var imageNode = node.QuerySelector("div#mainframe1.outframe ul.flexcontainer.zero li.flexitem.pad a img.thumb100 ");
            return new 
            {
                name = node.QuerySelector("p.pad.bo1 a").InnerText,
                image_link = imageNode != null ? imageNode.GetAttributeValue("src", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pinterest.com%2Fpin%2F792070653234421442%2F&psig=AOvVaw3MnJz2FggarzNZrD1a6FZR&ust=1696790185783000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCLCHsJTK5IEDFQAAAAAdAAAAABAE") : "Image not found"
            };
        });
        


        return Ok(data);
       
    }
}
