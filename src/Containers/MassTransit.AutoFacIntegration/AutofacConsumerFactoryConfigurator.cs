﻿// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.AutofacIntegration
{
	using System;
	using Autofac;
	using Magnum.Reflection;
	using SubscriptionConfigurators;

	public class AutofacConsumerFactoryConfigurator
	{
		readonly IContainer _container;
		SubscriptionBusServiceConfigurator _configurator;

		public AutofacConsumerFactoryConfigurator(SubscriptionBusServiceConfigurator configurator, IContainer container)
		{
			_container = container;
			_configurator = configurator;
		}

		public void ConfigureConsumer(Type messageType)
		{
			this.FastInvoke(new[] {messageType}, "Configure");
		}

		public void Configure<T>()
			where T : class
		{
			_configurator.Consumer(new AutofacConsumerFactory<T>(_container));
		}
	}
}