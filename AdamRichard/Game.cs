using System.ComponentModel;
using System.Dynamic;
using Xunit.Sdk;

namespace bowling;

public class Game
{
    private List<int> _throws = new List<int>();

    public Game()
    {
    }

    public void Bowl(int pins)
    {
        _throws.Add(pins);
    }
    
    public int Score()
    {
        var acc = 0;
        var throwIndex = 0;
        
        for (var frameIndex = 0; throwIndex < _throws.Count() && frameIndex < 10; frameIndex++)
            switch (GetFrameType(throwIndex))
            {
                case FrameType.Normal:
                    acc += GetThrow(throwIndex) + GetThrow(throwIndex+1);
                    throwIndex+=2;
                    break;
                case FrameType.Spare:
                    acc += 10 + GetThrow(throwIndex+2);
                    throwIndex+=2;
                    break;
                case FrameType.Strike:
                    acc += 10 + GetThrow(throwIndex+1) + GetThrow(throwIndex+2);
                    throwIndex+=1;
                    break;
            }
        
        return acc;
    }

    enum FrameType
    {
        Normal,
        Spare,
        Strike
    }

    private FrameType GetFrameType(int throwIndex)
    {
        if (GetThrow(throwIndex) == 10)
        {
            return FrameType.Strike;
        }
        else if (GetThrow(throwIndex) + GetThrow(throwIndex+1) == 10)
        {
            return FrameType.Spare;
        }
        return FrameType.Normal;
    }

    private int GetThrow(int index)
    {
        if (index < _throws.Count)
        {
            return _throws[index];
        } else
        {
            return 0;
        }
    }
}