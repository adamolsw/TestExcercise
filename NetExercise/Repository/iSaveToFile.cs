using NetExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetExercise.Repository
{
    public interface ISaveToFile
    {
        void SaveFile(Text text, string dirPath);
    }
}