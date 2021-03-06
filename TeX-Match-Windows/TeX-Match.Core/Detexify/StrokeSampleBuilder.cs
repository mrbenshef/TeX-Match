﻿using TeX_Match.Core.Detexify;

public class StrokeSampleBuilder
{
    unsafe void* builder;

    public StrokeSampleBuilder(uint capacity)
    {
        unsafe
        {
            builder = Bindings.StrokeSampleBuilderNew(capacity);
        }
    }

    public void AddStroke(Stroke stroke)
    {
        unsafe { Bindings.StrokeSampleBuilderAddStroke(builder, stroke.Ptr); }
    }

    public StrokeSample build()
    {
        unsafe { return new StrokeSample(Bindings.StrokeSampleBuilderBuild(builder)); }
    }
}