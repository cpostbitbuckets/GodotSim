using System.Collections;
using System.Collections.Generic;
using Godot;
using FRCSim;
using System.Threading.Tasks;

public class EventManager : Node
{
    public delegate void MotorConfigUpdateEventHandler(MotorConfig motorConfig);
    public delegate void RobotStateUpdateEventHandler(RobotState robotState);
    public delegate void SimulatorRunningEventhandler(bool simulatorRunning);
    public delegate void MotorOutputsUpdatedEventHandler(MotorOutputs motorOutputs);
    public delegate void PingedEventHandler();

    public static event MotorConfigUpdateEventHandler MotorConfigUpdated;
    public static event RobotStateUpdateEventHandler RobotStateUpdated;
    public static event SimulatorRunningEventhandler SimulatorRunning;
    public static event MotorOutputsUpdatedEventHandler MotorOutputsUpdated;
    public static event PingedEventHandler Pinged;

    public static EventManager Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public static void PublishMotorConfigUpdateEvent(MotorConfig motorConfig)
    {
        MotorConfigUpdated?.Invoke(motorConfig);
    }

    public static void PublishRobotStateUpdateEvent(RobotState robotState)
    {
        RobotStateUpdated?.Invoke(robotState);
    }

    public static void PublishSimulatorRunningEvent(bool simulatorRunning)
    {
        SimulatorRunning?.Invoke(simulatorRunning);
    }

    public static void PublishMotorOutputsUpdatedEvent(MotorOutputs motorOutputs)
    {
        // GD.Print("Publshing new motor outputs");
        MotorOutputsUpdated?.Invoke(motorOutputs);
    }

    public static void PublishPingedEvent()
    {
        // GD.Print("Publshing new motor outputs");
        Pinged?.Invoke();
    }

}
