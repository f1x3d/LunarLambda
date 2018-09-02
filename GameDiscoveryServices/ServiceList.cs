﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDiscoveryServices
{
	public static class ServiceList
	{
		public static List<HostedService> KnownServices = new List<HostedService>();
		public static List<HostedService> LocalServices = new List<HostedService>();

		public static void RegisterLocalService(HostedService localService, bool publish)
		{
			var existing = LocalServices.Find((x) => x.Key == localService.Key);
			if (existing != null)
				LocalServices.Remove(existing);

			LocalServices.Add(existing);

			if (publish)
				InternetDiscoveryConnection.PushPublicSevice(localService);
		}

		internal static void AddRemoteService(HostedService service)
		{
			var existing = LocalServices.Find((x) => x.Key == service.Key);
			if (existing != null)
				return;

			existing = KnownServices.Find((x) => x.Key == service.Key);
			if (existing != null)
				KnownServices.Remove(existing);

			KnownServices.Add(service);
		}
	}
}