﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Udt;

namespace UdtProtocol_Test
{
	/// <summary>
	/// Test fixture for <see cref="KeepAlivePacket"/>.
	/// </summary>
	[TestFixture]
	public class KeepAlivePacketTest
	{
		[Test]
		public void Create_and_dispose()
		{
			KeepAlivePacket packet = new KeepAlivePacket();
			
			Assert.AreEqual(0, packet.DestinationId);
			Assert.IsFalse(packet.IsDisposed);
			Assert.IsTrue(packet.IsEditable);
			Assert.AreEqual(TimeSpan.Zero, packet.TimeStamp);

			packet.Dispose();

			Assert.Throws<ObjectDisposedException>(() => { var x = packet.DestinationId; });
			Assert.IsTrue(packet.IsDisposed);
			Assert.IsFalse(packet.IsEditable);
			Assert.Throws<ObjectDisposedException>(() => { var x = packet.TimeStamp; });
		}
	}
}
