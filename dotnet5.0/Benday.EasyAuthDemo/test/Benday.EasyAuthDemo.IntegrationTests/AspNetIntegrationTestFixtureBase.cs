using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.ServiceLayers;
using Benday.EasyAuthDemo.WebUi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.IntegrationTests
{
    public abstract class AspNetIntegrationTestFixtureBase<TEntryPoint> where TEntryPoint : class
    {
        protected void Reset()
        {
            _WebApplicationInstance = null;
            _Client = null;
            _Scope = null;
            _HostServices = null;
        }

        protected WebApplicationFactory<TEntryPoint> _WebApplicationInstance;
        protected WebApplicationFactory<TEntryPoint> WebApplicationInstance
        {
            get
            {
                if (_WebApplicationInstance == null)
                {
                    _WebApplicationInstance =
                        new WebApplicationFactory<TEntryPoint>();
                }

                return _WebApplicationInstance;
            }
        }

        protected T CreateInstance<T>()
        {
            var provider = Scope.ServiceProvider;

            var returnValue = provider.GetService<T>();

            return returnValue;
        }

        protected HttpClient _Client;
        protected HttpClient Client
        {
            get
            {
                if (_Client == null)
                {
                    _Client = WebApplicationInstance.CreateDefaultClient();
                }

                return _Client;
            }
        }

        private void EnsureClientIsInitialized()
        {
            if (Client == null)
            {
                Assert.Fail("Client could not be initialized.");
            }
        }

        protected IServiceProvider _HostServices;
        protected IServiceProvider HostServices
        {
            get
            {
                if (_HostServices == null)
                {
                    _HostServices = WebApplicationInstance.Server.Host.Services;
                }

                return _HostServices;
            }
        }

        protected IServiceScope _Scope;
        protected IServiceScope Scope
        {
            get
            {
                if (_Scope == null)
                {
                    EnsureClientIsInitialized();

                    var scopeFactory = HostServices.GetService(
                        typeof(IServiceScopeFactory)) as IServiceScopeFactory;

                    _Scope = scopeFactory.CreateScope();
                }

                return _Scope;
            }
        }

        private readonly string START_OF_DI_ERROR_MSG = "System.InvalidOperationException: Unable to resolve service for type ";
        private readonly string MIDDLE_OF_DI_ERROR_MSG = "while attempting to activate ";
        protected bool IsDependencyInjectionError(string content)
        {
            if (content.StartsWith(START_OF_DI_ERROR_MSG) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected string GetDependencyInjectionErrorInfo(string content)
        {
            int indexOfStartOfMessage = content.IndexOf(START_OF_DI_ERROR_MSG);
            int indexOfFailedInterface = indexOfStartOfMessage + START_OF_DI_ERROR_MSG.Length;
            int indexOfFailedClassMessage = content.IndexOf(MIDDLE_OF_DI_ERROR_MSG);
            int indexOfFailedClass = indexOfFailedClassMessage + MIDDLE_OF_DI_ERROR_MSG.Length;
            int indexOfEndOfError = content.IndexOf("'.", indexOfFailedClass);
            
            if (indexOfStartOfMessage == -1 || indexOfFailedClassMessage == -1)
            {
                return null;
            }
            else
            {
                var failedInterface =
                    content.Substring(indexOfFailedInterface, 
                    (indexOfFailedClassMessage - indexOfFailedInterface));

                var failedClass =
                    content.Substring(indexOfFailedClass,
                    indexOfEndOfError - indexOfFailedClass);

                return String.Format("Tried to create {0} for {1}'.  Check type registrations in Startup.cs.",
                    failedInterface.Trim(), failedClass.Trim());
            }
        }

		protected async Task CheckForDependencyInjectionError(
			HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode == false)
            {
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Content from server: {0}", content);

                if (IsDependencyInjectionError(content) == true)
                {
                    Assert.Fail(GetDependencyInjectionErrorInfo(content));
                }
            }
		}
    }
}
