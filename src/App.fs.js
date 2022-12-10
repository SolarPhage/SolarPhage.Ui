import * as main from "./scss/main.scss";
import { Union, Record } from "./fable_modules/fable-library.3.7.20/Types.js";
import { union_type, record_type, int32_type } from "./fable_modules/fable-library.3.7.20/Reflection.js";
import { createElement } from "react";
import { ofArray } from "./fable_modules/fable-library.3.7.20/List.js";
import { Interop_reactApi } from "./fable_modules/Feliz.1.68.0/./Interop.fs.js";
import { ProgramModule_mkSimple, ProgramModule_run } from "./fable_modules/Fable.Elmish.3.1.0/program.fs.js";
import { Program_withReactSynchronous } from "./fable_modules/Fable.Elmish.React.3.0.1/react.fs.js";


export class State extends Record {
    constructor(Count) {
        super();
        this.Count = (Count | 0);
    }
}

export function State$reflection() {
    return record_type("App.State", [], State, () => [["Count", int32_type]]);
}

export class Msg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Increment", "Decrement"];
    }
}

export function Msg$reflection() {
    return union_type("App.Msg", [], Msg, () => [[], []]);
}

export function init() {
    return new State(0);
}

export function update(msg, state) {
    if (msg.tag === 1) {
        return new State(state.Count - 1);
    }
    else {
        return new State(state.Count + 1);
    }
}

export function render(state, dispatch) {
    const children = ofArray([createElement("button", {
        onClick: (_arg) => {
            dispatch(new Msg(0));
        },
        children: "Increment",
    }), createElement("button", {
        onClick: (_arg_1) => {
            dispatch(new Msg(1));
        },
        children: "Decrement",
    }), createElement("h1", {
        children: [state.Count],
    })]);
    return createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    });
}

ProgramModule_run(Program_withReactSynchronous("elmish-app", ProgramModule_mkSimple(init, update, render)));

