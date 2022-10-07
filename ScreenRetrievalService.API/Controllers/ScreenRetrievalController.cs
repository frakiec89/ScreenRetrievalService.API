using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScreenRetrievalService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenRetrievalController : ControllerBase
    {
        public static List<ImagePost> ImagePosts { get; set; } = new List<ImagePost>();

        [HttpPost("PictureReception")] 
        public void PictureReception( ImagePost  bytes)
        {

            if(ImagePosts.Any(x=>x.key == bytes.key) == false)
            {
                ImagePosts.Add(bytes);
                return; 
            }

            if( ImagePosts.Any(x=>x.key == bytes.key))
            {
                var image = ImagePosts.Single(x => x.key == bytes.key); 
                image.timeShet = bytes.timeShet;
                image.bytes = bytes.bytes; 
            }
        }

        [HttpGet ("GetPicture")]
        public  ImagePost GetBytes (string key )
        {
            if (ImagePosts == null)
                return new ImagePost();

            if(ImagePosts.Count == 0)
                return new ImagePost();


            if (ImagePosts.Any(x=>x.key == key))
                return  ImagePosts.Single(x=>x.key == key) ;
            else
                return new ImagePost(); 
        }

        [HttpGet("StopStream")]
        public void StopStram (string key)
        {
            ImagePosts.RemoveAll(x => x.key == key);
        }

        [HttpGet("IsChekedKey")]
        public bool IsChekedKey(string key)
        {
            var r = ImagePosts.Any(x => x.key == key);
            return r; 
        }

    }

    public class ImagePost
    {
        public byte[] bytes { get; set; }
        public string key { get; set; }
        public DateTime timeShet { get; set; }
    }
}
