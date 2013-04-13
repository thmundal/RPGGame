using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using System.Security; 

public class GUI_Element {
	// Private variables
	private GUI_Type _type;
	private GUI_Align _align;
	private bool _visible;
	private Vector2 _position;
	private Vector2 _size;
	
	// Public variables
	
	#region Constructor and Overloads
	/// <summary>
	/// Initializes a new instance of the <see cref="GUI_Element"/> class.
	/// </summary>
	/// <param name='Type'>
	/// Type.
	/// </param>
	/// <param name='Position'>
	/// Position.
	/// </param>
	/// <param name='Align'>
	/// Align.
	/// </param>
	public GUI_Element(GUI_Type type, Vector2 Position, Vector2 Size, GUI_Align Align) {
		_type = type;
		_align = Align;
		_visible = true;
		_position = Position;
		_size = Size;
	}
	/// <summary>
	/// Initializes a new instance of the <see cref="GUI_Element"/> class.
	/// </summary>
	/// <param name='Type'>
	/// Type.
	/// </param>
	/// <param name='Position'>
	/// Position.
	/// </param>
	public GUI_Element(GUI_Type type, Vector2 Position, Vector2 Size) {
		_type = type;
		_align = GUI_Align.None;
		_visible = true;
		_position = Position;
		_size = Size;
	}
	#endregion
	
	public void Display() {
		if(_visible == true) {
			Type type = typeof(GUI);
			System.Object obj = Activator.CreateInstance(type);
			MethodInfo method = type.GetMethod(_type.ToString());
			method.Invoke(obj, new object[] { CreatePosition() });
		}
	}
	
	private Rect CreatePosition() {
		return new Rect(_position.x, _position.y, _size.x, _size.y);
	}
}

public enum GUI_Type {
	Box,
	Button,
	RepeatButton,
	TextField,
	PasswordField,
	TextArea,
	Toggle,
	Toolbar,
	SelectionGrid,
	HorizontalScrollbar,
	VerticalScrollbar
}

public enum GUI_Align {
	None,
	Left,
	Right,
	Center,
	Top,
	Bottom
}