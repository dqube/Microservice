﻿namespace CompanyName.MyProjectName.BuildingBlocks.Saga;

public class SagaContextError
{
    public Exception Exception { get; }

    public SagaContextError(Exception e)
    {
        Exception = e;
    }
}
