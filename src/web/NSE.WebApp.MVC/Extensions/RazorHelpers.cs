﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Razor;

namespace NSE.WebApp.MVC.Extensions
{
	public static class RazorHelpers
	{
		public static string HashEmailForGravatar(this RazorPage page, string email)
        {
			var md5Hasher = MD5.Create();
			var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));
			var sBuilder = new StringBuilder();
			foreach(var t in data)
            {
				sBuilder.Append(t.ToString(format: "x2"));
            }

			return sBuilder.ToString();
        }

		public static string MoneyFormat(this RazorPage page, decimal value)
        {
			return value > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", value) : "Gratuito";
        }

		public static string MessageStock(this RazorPage page, int quantity)
        {
			return quantity > 0 ? $"Apenas {quantity} em estoque!" : "Produto esgotado!";
        }
	}
}

