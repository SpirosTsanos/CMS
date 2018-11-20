using System;

namespace CMS.Tools
{
    public interface IFlowElement
    {
        bool IsHomeView { get; }
        bool IsLastView { get; }
    }
}