﻿
using Bonsai.Core;

namespace Bonsai.Standard
{
  /// <summary>
  /// Keep re-traversing children until the child return success.
  /// </summary>
  [BonsaiNode("Decorators/", "RepeatArrow")]
  public class UntilSuccess : Decorator
  {
    public override Status Run()
    {
      Status s = Iterator.LastStatusReturned;

      if (s == Status.Success)
      {
        return Status.Success;
      }

      // Retraverse child.
      Iterator.Traverse(_child);

      return Status.Running;
    }
  }
}