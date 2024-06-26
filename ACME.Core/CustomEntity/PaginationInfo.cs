﻿namespace ACME.Core.CustomEntity;

public class PaginationInfo<T>
{
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public List<T> Data { get; set; }
}
