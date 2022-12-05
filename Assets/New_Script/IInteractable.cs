using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Act(Interactor interactor);

    public void Focused(Interactor interactor);

    public void UnFocused(Interactor interactor);

}
