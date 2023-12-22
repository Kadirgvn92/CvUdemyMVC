using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvUdemyMVC.DtoLayer.ExprienceDto;
public class CreateExprienceDto
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
}
