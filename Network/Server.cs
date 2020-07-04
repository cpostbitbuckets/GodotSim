using Godot;
using Grpc.Core;
using System.Threading.Tasks;
using System;
using FRCSim;

public class Server : Node
{
	private Grpc.Core.Server server;

	public override void _EnterTree()
	{
		// unity runs on port 50052
		// java runs on 50051
		const int port = 50052;

		server = new Grpc.Core.Server
		{
			Services = {
				FRCSim.RobotService.BindService(new RobotService()),
				FRCSim.PingService.BindService(new PingService())
			},
			Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) },
		};

		GD.Print("Starting server on port: " + port);
		server.Start();
		GD.Print("Started server on port: " + port);
	}

	public override void _ExitTree()
	{
		GD.Print("Stopping server");
		// shutdown the server
		try
		{
			server.ShutdownAsync().Wait(1000);
			GD.Print("Server is stopped.");
		}
		catch (Exception e)
		{
			GD.Print("Server did not shutdown in 1s, killing it." + e);
			server.KillAsync().Wait();
		}
	}

}
