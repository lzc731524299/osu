﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.UserInterface.Tab;
using osu.Framework.Screens.Testing;
using osu.Game.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Game.Screens.Select.Filter;
using osu.Game.Screens.Select.Tab;

namespace osu.Desktop.VisualTests.Tests
{
    public class TestCaseTabControl : TestCase
    {
        public override string Description => @"Filter for song select";

        public override void Reset()
        {
            base.Reset();

            OsuSpriteText text;
            FilterTabControl<GroupMode> filter;

            Add(new FillFlowContainer
            {
                Direction = FillDirection.Horizontal,
                AutoSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    filter = new FilterTabControl<GroupMode>(GroupMode.All, GroupMode.RecentlyPlayed)
                    {
                        Width = 229,
                        AutoSort = true
                    },
                    text = new OsuSpriteText
                    {
                        Text = "None",
                        Margin = new MarginPadding(4)
                    }
                }
            });
            
            filter.ValueChanged += (sender, mode) =>
            {
                Debug.WriteLine($"Selected {mode}");
                text.Text = mode.ToString();
            };
        }
    }
}