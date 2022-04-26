using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CourseProject.WebApi3.Controllers
{
    public class FileController : ApiController
    {
        //public async Task<IHttpActionResult> PostUploadFile()
        //{
        //    try
        //    {
        //        var provider = new MultipartMemoryStreamProvider();
        //        await Request.Content.ReadAsMultipartAsync(provider);

        //        if (provider.Contents != null && provider.Contents.Count > 0)
        //        {
        //            foreach (var file in provider.Contents)
        //            {
        //                if (file.Headers.ContentDisposition.FileName != null)
        //                {
        //                    var filename = file.Headers.ContentDisposition.FileName;
        //                    var saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
        //                    if (!Directory.Exists(saveDir))
        //                    {
        //                        Directory.CreateDirectory(saveDir);
        //                    }
        //                    var filePath = Path.Combine(saveDir, filename);
        //                    if (File.Exists(filePath))
        //                    {
        //                        File.Delete(filePath);
        //                    }
        //                    var bites = await file.ReadAsByteArrayAsync();
        //                    if (bites != null && bites.Length > 0)
        //                    {
        //                        using (MemoryStream streamMemory = new MemoryStream(bites))
        //                        {
        //                            streamMemory.Seek(0, SeekOrigin.Begin);
        //                            using(var fileStream = File.Create(filePath))
        //                            {
        //                                streamMemory.CopyTo(fileStream);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        return Ok(new { message = "File empty" });
        //                    }
        //                }
        //                else
        //                {
        //                    return Ok(new { message = "No file name" });
        //                }
        //            }

        //            return Ok("файлы загружены");
        //        }
        //        else
        //        {
        //            return Ok(new { message = "Not found" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }

            string roots = Path.Combine(AppDomain.CurrentDomain.DynamicDirectory, "Files");
            var provider = new MultipartMemoryStreamProvider();
            // путь к папке на сервере
            string root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                byte[] fileArray = await file.ReadAsByteArrayAsync();

                using (FileStream fs = new FileStream(root + filename, FileMode.Create))
                {
                    await fs.WriteAsync(fileArray, 0, fileArray.Length);
                }
            }
            return Ok("файлы загружены");
        }
    }
}
