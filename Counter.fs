namespace CelticLegendsTimers

module Counter =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.Layout
    open System

    type State = { count: int }
    let init = { count = 0 }
    type TimeState = { myDateTime: DateTime }
    let timeInit = { myDateTime = DateTime.Now }

    type Msg =
        | Increment
        | Decrement
        | Reset

    type TimeMsg =
        | TimeIncrement
        | TimeDecrement
        | TimeReset

    let updateTime (msg: TimeMsg) (state: TimeState) : TimeState =
        match msg with
        | TimeIncrement -> { state with myDateTime = (DateTime.Now).AddMinutes(20000)}
        | TimeDecrement -> { state with myDateTime = (DateTime.Now).AddMinutes(-20000)}
        | TimeReset -> timeInit

    let update (msg: Msg) (state: State) : State =
        match msg with
        | Increment -> { state with count = state.count + 1 }
        | Decrement -> { state with count = state.count - 1 }
        | Reset -> init

    let view (state: State) (dispatch) =
        StackPanel.create
            [ StackPanel.margin 5.0
              StackPanel.spacing 5.0
              StackPanel.children
                  [ Button.create
                        [ Button.onClick (fun _ -> dispatch Increment)
                          Button.content "+"
                          Button.classes [ "plus" ] ]
                    Button.create
                        [ Button.onClick (fun _ -> dispatch Decrement)
                          Button.content "-"
                          Button.classes [ "minus" ] ]
                    Button.create [ Button.onClick (fun _ -> dispatch Reset); Button.content "reset" ]
                    (* Button.create *)
                    (*     [ Button.onClick (fun _ -> dispatch TimeIncrement) *)
                    (*       Button.content "+time" *)
                    (*       Button.classes [ "plus" ] ] *)
                    (* Button.create *)
                    (*     [ Button.onClick (fun _ -> dispatch TimeDecrement) *)
                    (*       Button.content "-time" *)
                    (*       Button.classes [ "minus" ] ] *)
                    (* Button.create [ Button.onClick (fun _ -> dispatch Reset); Button.content "reset time" ] *)
                    CalendarDatePicker.create [
                         CalendarDatePicker.selectedDate DateTime.Today
                    ]
                    TextBlock.create [ TextBlock.text ("Derek is cool") ]
                    TimePicker.create [ TimePicker.selectedTime (TimeSpan 99999999) ]
                    DatePicker.create
                        [ DatePicker.selectedDate DateTime.Today
                          DatePicker.yearFormat "yyyy"
                          DatePicker.monthFormat "MMMM"
                          DatePicker.dayFormat "dd" ] ] ]

