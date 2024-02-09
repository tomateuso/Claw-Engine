﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Claw.Graphics.UI
{
    /// <summary>
    /// Responsável pelo controle de toda a interface.
    /// </summary>
    public sealed class UI
    {
        /// <summary>
        /// Define se o <see cref="NineSlice"/> dos elementos deverá desenhar a textura central escalada.
        /// </summary>
        public bool ScaleCenter = true;
        public Vector2 Offset = Vector2.Zero;
        public Container Body;
        public Dictionary<string, Style> Styles = new Dictionary<string, Style>();

        /// <summary>
        /// Recalcula o tamanho dos elementos visíveis.
        /// </summary>
        public void Recalculate() => Body.UpdateRealSize();

        public void Render()
        {
            bool previousIgnore = Draw.IgnoreCamera;
            Draw.IgnoreCamera = false;
            
            if (Body != null)
            {
                Vector2 bodyPosition = Offset + Body.Style.Offset;

                Body.Render(bodyPosition);
            }

            Draw.IgnoreCamera = previousIgnore;
        }
    }
}