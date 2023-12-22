using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvUdemyMVC.DtoLayer.AboutDto;
public class GetAboutDto
{
    public int AboutID { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}
