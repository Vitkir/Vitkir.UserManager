using System;

namespace Vitkir.UserManager.Common.DigitalSignatureWorker
{
	public static class RandomGenerator
	{
		private static Random random = new Random();

		public static int GetRandomInt(int min = 1000, int max = 1000000)
		{
			return random.Next(min, max);
		}
	}
}
