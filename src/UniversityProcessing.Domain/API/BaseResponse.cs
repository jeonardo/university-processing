﻿using System;
using System.Text.Json;

namespace UniversityProcessing.Domain.API;

/// <summary>
/// Base class used by API responses
/// </summary>
public abstract record BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlationId) : base(correlationId) { }

    public bool Success { get; private set; }

    public int StatusCode { get; private set; }

    public string Message { get; private set; } = string.Empty;

    public void SetResult(bool success, int statusCode, string message)
    {
        Success = success;
        StatusCode = statusCode;
        Message = message;
    }

    public void SetSuccessResult(int statusCode, string message)
    {
        Success = true;

        //TODO Validate StatusCode

        StatusCode = statusCode;
        Message = message;
    }

    public void SetErrorResult(int statusCode, string message)
    {
        Success = false;

        //TODO Validate StatusCode

        StatusCode = statusCode;
        Message = message;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
