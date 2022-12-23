import * as main from "./scss/main.scss";
import { Msg, DataResult$1, Model, Game, Character, Page } from "./Types.fs.js";
import { ofArray, singleton, empty } from "./fable_modules/fable-library.3.7.20/List.js";
import { Cmd_none, Cmd_batch } from "./fable_modules/Fable.Elmish.4.0.0/cmd.fs.js";
import { Cmd_OfAsync_start, Cmd_OfAsyncWith_either } from "./fable_modules/Fable.Elmish.4.0.0/./cmd.fs.js";
import { getCharacters, getCharacter } from "./Infrastructure/Characters.fs.js";
import { getGames, getGame } from "./Infrastructure/Games.fs.js";
import { render as render_1 } from "./Views/CharacterSelect.fs.js";
import { render as render_2 } from "./Views/CombatMenu.fs.js";
import { render as render_3 } from "./Views/CombatPhotocastsMenu.fs.js";
import { render as render_4 } from "./Views/CombatPotionMenu.fs.js";
import { render as render_5 } from "./Views/CreateCharacter.fs.js";
import { render as render_6 } from "./Views/CreateGame.fs.js";
import { render as render_7 } from "./Views/DungeonMenu.fs.js";
import { render as render_8 } from "./Views/GameCharacterMenu.fs.js";
import { render as render_9 } from "./Views/GameInventoryMenu.fs.js";
import { render as render_10 } from "./Views/GameInventoryPhotocastMenu.fs.js";
import { render as render_11 } from "./Views/GameMenu.fs.js";
import { render as render_12 } from "./Views/GamePhotocastMenu.fs.js";
import { render as render_13 } from "./Views/MainMenu.fs.js";
import { render as render_14 } from "./Views/PostCombatMenu.fs.js";
import { render as render_15 } from "./Views/ShopBuyItem.fs.js";
import { render as render_16 } from "./Views/ShopInventoryItem.fs.js";
import { render as render_17 } from "./Views/ShopMenu.fs.js";
import { render as render_18 } from "./Views/TownMenu.fs.js";
import { render as render_19 } from "./Views/ActiveGameMenu.fs.js";
import { ProgramModule_mkProgram, ProgramModule_run } from "./fable_modules/Fable.Elmish.4.0.0/program.fs.js";
import { Program_withReactSynchronous } from "./fable_modules/Fable.Elmish.React.3.0.1/react.fs.js";


export function init() {
    return [new Model(0, new Page(0), new Character(0, "test", 0, false, empty()), empty(), new Game(5, 5), empty()), Cmd_batch(ofArray([singleton((dispatch) => {
        dispatch(new Msg(4, new DataResult$1(0)));
    }), singleton((dispatch_1) => {
        dispatch_1(new Msg(2, new DataResult$1(0)));
    })]))];
}

export function update(msg, state) {
    if (msg.tag === 1) {
        if (msg.fields[0][1].tag === 1) {
            const character = msg.fields[0][1].fields[0];
            return [new Model(state.Count, state.CurrentPage, character, state.Characters, state.Game, state.Games), Cmd_none()];
        }
        else {
            const id_2 = msg.fields[0][0] | 0;
            return [state, Cmd_OfAsyncWith_either((x) => {
                Cmd_OfAsync_start(x);
            }, getCharacter, id_2, (arg) => (new Msg(1, arg)), (arg_1) => (new Msg(5, arg_1)))];
        }
    }
    else if (msg.tag === 2) {
        if (msg.fields[0].tag === 1) {
            const characters = msg.fields[0].fields[0];
            return [new Model(state.Count, state.CurrentPage, state.Character, characters, state.Game, state.Games), Cmd_none()];
        }
        else {
            return [state, Cmd_OfAsyncWith_either((x_1) => {
                Cmd_OfAsync_start(x_1);
            }, getCharacters, void 0, (arg_3) => (new Msg(2, arg_3)), (arg_4) => (new Msg(5, arg_4)))];
        }
    }
    else if (msg.tag === 3) {
        if (msg.fields[0][1].tag === 1) {
            const game = msg.fields[0][1].fields[0];
            return [new Model(state.Count, state.CurrentPage, state.Character, state.Characters, game, state.Games), Cmd_none()];
        }
        else {
            const id_3 = msg.fields[0][0] | 0;
            return [state, Cmd_OfAsyncWith_either((x_2) => {
                Cmd_OfAsync_start(x_2);
            }, getGame, id_3, (arg_6) => (new Msg(3, arg_6)), (arg_7) => (new Msg(5, arg_7)))];
        }
    }
    else if (msg.tag === 4) {
        if (msg.fields[0].tag === 1) {
            const games = msg.fields[0].fields[0];
            return [new Model(state.Count, state.CurrentPage, state.Character, state.Characters, state.Game, games), Cmd_none()];
        }
        else {
            return [state, Cmd_OfAsyncWith_either((x_3) => {
                Cmd_OfAsync_start(x_3);
            }, getGames, void 0, (arg_9) => (new Msg(4, arg_9)), (arg_10) => (new Msg(5, arg_10)))];
        }
    }
    else if (msg.tag === 5) {
        const error = msg.fields[0];
        return [state, Cmd_none()];
    }
    else {
        const page = msg.fields[0];
        switch (page.tag) {
            case 2: {
                const id = page.fields[0] | 0;
                return [new Model(state.Count, page, state.Character, state.Characters, state.Game, state.Games), singleton((dispatch) => {
                    dispatch(new Msg(3, [id, new DataResult$1(0)]));
                })];
            }
            case 1: {
                const id_1 = page.fields[0] | 0;
                return [new Model(state.Count, page, state.Character, state.Characters, state.Game, state.Games), singleton((dispatch_1) => {
                    dispatch_1(new Msg(1, [id_1, new DataResult$1(0)]));
                })];
            }
            default: {
                return [new Model(state.Count, page, state.Character, state.Characters, state.Game, state.Games), Cmd_none()];
            }
        }
    }
}

export function render(state, dispatch) {
    const matchValue = state.CurrentPage;
    switch (matchValue.tag) {
        case 1: {
            return render_1(state, dispatch);
        }
        case 15: {
            return render_2(dispatch);
        }
        case 17: {
            return render_3(dispatch);
        }
        case 16: {
            return render_4(dispatch);
        }
        case 3: {
            return render_5(dispatch);
        }
        case 4: {
            return render_6(dispatch);
        }
        case 14: {
            return render_7(dispatch);
        }
        case 10: {
            return render_8(dispatch);
        }
        case 12: {
            return render_9(dispatch);
        }
        case 13: {
            return render_10(dispatch);
        }
        case 9: {
            return render_11(dispatch);
        }
        case 11: {
            return render_12(dispatch);
        }
        case 0: {
            return render_13(state, dispatch);
        }
        case 18: {
            return render_14(dispatch);
        }
        case 7: {
            return render_15(dispatch);
        }
        case 8: {
            return render_16(dispatch);
        }
        case 6: {
            return render_17(dispatch);
        }
        case 5: {
            return render_18(dispatch);
        }
        default: {
            return render_19(state, dispatch);
        }
    }
}

ProgramModule_run(Program_withReactSynchronous("elmish-app", ProgramModule_mkProgram(init, update, render)));

