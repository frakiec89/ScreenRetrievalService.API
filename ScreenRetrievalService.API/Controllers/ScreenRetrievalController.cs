using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScreenRetrievalService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenRetrievalController : ControllerBase
    {
        public static byte[] DataImage { get; set; }

        [HttpPost("PictureReception")] 
        public void PictureReception( ImagePost  bytes)
        {
            if(bytes != null)   
                DataImage = bytes.Bytes;
        }

        [HttpGet ("GetPicture")]
        public  ImagePost GetBytes ()
        {
            if (DataImage != null)
                return new ImagePost() { Bytes = DataImage };
            else
                return new ImagePost(); 
        }
    }

    public class ImagePost
    {
        public byte[] Bytes { get; set; }
    }
}
