﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvUdemyMVC.DtoLayer.SkillDto;
public class GetSkillDto
{
    public int SkillID { get; set; }
    public string Title { get; set; }

    public string Percentage { get; set; }
}
