using Robust.Shared.Utility;
using static Robust.Shared.Maths.MathHelper;

namespace Content.Shared._Orion.Maths.Extensions;

//
// License-Identifier: GPL-3.0-or-later
//

public static class Box2Ext
{
    public static List<Box2> Subtract(this Box2 box, Box2 other, float tolerance = .0000001f)
    {
        var intersectedPercentage = other.IntersectPercentage(box);

        if (CloseTo(intersectedPercentage, 1f, tolerance))
            return new();

        if (other.IsEmpty() || CloseTo(intersectedPercentage, 0f, tolerance))
            return new() { box };

        var intersected = other.Intersect(box);

        var list = new List<Box2>();

        // Left
        if (!CloseTo(intersected.Left, box.Left, tolerance))
        {
            var boxLeft = new Box2(box.Left, box.Bottom, intersected.Left, box.Top);
            list.Add(boxLeft);
        }

        // Right
        if (!CloseTo(intersected.Right, box.Right, tolerance))
        {
            var boxRight = new Box2(intersected.Right, box.Bottom, box.Right, box.Top);
            list.Add(boxRight);
        }

        // Top
        if (!CloseTo(intersected.Top, box.Top, tolerance))
        {
            var boxTop = new Box2(intersected.Left, intersected.Top, intersected.Right, box.Top);
            list.Add(boxTop);
        }

        // Bottom
        if (!CloseTo(intersected.Bottom, box.Bottom, tolerance))
        {
            var boxBottom = new Box2(intersected.Left, box.Bottom, intersected.Right, intersected.Bottom);
            list.Add(boxBottom);
        }

        DebugTools.Assert(list.Count != 0);

        return list;
    }
}
