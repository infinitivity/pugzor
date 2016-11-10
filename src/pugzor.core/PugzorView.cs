﻿using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.NodeServices;

namespace pugzor.core
{
    public class PugzorView : IView
    {
        private string _path;
        private IPugRendering _pugRendering;

        public PugzorView(string path, IPugRendering pugRendering)
        {
            _path = path;
        }

        public string Path
        {
            get
            {
                return _path;
            }
        }

        public async Task RenderAsync(ViewContext context)
        {
            var result = await _pugRendering.Render(Path, context.ViewData.Model);
            context.Writer.Write(result);
        }
    }
}
