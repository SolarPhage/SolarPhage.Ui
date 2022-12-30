module App.Types.Shared

type DataResult<'t> = 
    | Loading
    | Result of 't