using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace exer6_01.GlobalFactory2021;

public partial class LightweightEf  
{
    public static void Default(){
        var db = new Globalfactory2021Context();
        // EF 会追踪所有获取的和改变的实体
        var product = db.Products.ToList();

        db.Dispose();
    }
    public static void AsNoTracking(){
        var db = new Globalfactory2021Context();
        var product = db.Products.AsNoTracking().ToList();
        db.Dispose();
    }
}