using System;

namespace Application.Scripts.Domain
{
    public interface IWebClient
    {
        IObservable<string> Get(string url);
    }
}