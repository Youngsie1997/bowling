using System.ComponentModel;
using System.Dynamic;
using System.Text;
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

    internal string GetScoreCardText()
    {
        var line1 = new StringBuilder("| F1  | F2  | F3  | F4  | F5  | F6  | F7  | F8  | F9  | F10   |");
        var line2 = new StringBuilder();
        var line3 = new StringBuilder();

        var acc = 0;
        var throwIndex = 0;
        
        for (var frameIndex = 0; throwIndex < _throws.Count() && frameIndex < 10; frameIndex++)
            switch (GetFrameType(throwIndex))
            {
                case FrameType.Normal:
                    acc += GetThrow(throwIndex) + GetThrow(throwIndex+1);
                    line2.AppendFormat($"| {GetThrow(throwIndex)} {GetThrow(throwIndex+1)} ");
                    line3.AppendFormat($"| {acc.ToString("000")} ");
                    
                    throwIndex+=2;
                    break;
                case FrameType.Spare:
                    acc += 10 + GetThrow(throwIndex+2);
                    line2.AppendFormat($"| {GetThrow(throwIndex)} / ");
                    line3.AppendFormat($"| {acc.ToString("000")} ");

                    throwIndex+=2;
                    break;
                case FrameType.Strike:
                    acc += 10 + GetThrow(throwIndex+1) + GetThrow(throwIndex+2);
                    line2.AppendFormat($"|  X  ");
                    line3.AppendFormat($"| {acc.ToString("000")} ");

                    throwIndex+=1;
                    break;
            }
        
        return String.Join(Environment.NewLine, new []{line1, line2, line3});
    }
}