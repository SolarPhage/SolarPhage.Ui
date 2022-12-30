import * as main from "./scss/main.scss";
import { Msg as Msg_2, CharacterState, Character } from "./Types/CharacterTypes.fs.js";
import { ofArray, singleton, empty } from "./fable_modules/fable-library.3.7.20/List.js";
import { Msg, GameState, Game } from "./Types/GameTypes.fs.js";
import { Msg as Msg_1, State, DungeonInfo, Page } from "./Types/AppTypes.fs.js";
import { Cmd_map, Cmd_none, Cmd_batch } from "./fable_modules/Fable.Elmish.4.0.0/cmd.fs.js";
import { DataResult$1 } from "./Types/SharedTypes.fs.js";
import { update as update_1 } from "./Modules/Character.fs.js";
import { update as update_2 } from "./Modules/Game.fs.js";
import { Cmd_OfAsync_start, Cmd_OfAsyncWith_either } from "./fable_modules/Fable.Elmish.4.0.0/./cmd.fs.js";
import { getDungeon } from "./Infrastructure/Dungeon.fs.js";
import { getShopItems } from "./Infrastructure/Shop.fs.js";
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


export const initCharacterState = new CharacterState(new Character(0, ""), empty());

export const initGameState = new GameState(new Game(5, 5), empty());

export function init() {
    return [new State(0, new Page(0), new DungeonInfo(5, 1), empty(), initGameState, initCharacterState), Cmd_batch(ofArray([singleton((dispatch) => {
        dispatch(new Msg_1(5, new Msg(1, new DataResult$1(0))));
    }), singleton((dispatch_1) => {
        dispatch_1(new Msg_1(4, new Msg_2(2, new DataResult$1(0))));
    })]))];
}

export function update(msg, state) {
    if (msg.tag === 0) {
        const page_1 = msg.fields[0];
        return [new State(state.Count, page_1, state.Dungeon, state.ShopItems, state.GameState, state.CharacterState), Cmd_none()];
    }
    else if (msg.tag === 4) {
        const characterMsg = msg.fields[0];
        const patternInput = update_1(characterMsg, state.CharacterState);
        const cmd = patternInput[1];
        const cState = patternInput[0];
        const appCmd = Cmd_map((x) => (new Msg_1(4, x)), cmd);
        return [new State(state.Count, state.CurrentPage, state.Dungeon, state.ShopItems, state.GameState, cState), appCmd];
    }
    else if (msg.tag === 5) {
        const gameMsg = msg.fields[0];
        const patternInput_1 = update_2(gameMsg, state.GameState);
        const gState = patternInput_1[0];
        const cmd_1 = patternInput_1[1];
        const appCmd_1 = Cmd_map((x_1) => (new Msg_1(5, x_1)), cmd_1);
        return [new State(state.Count, state.CurrentPage, state.Dungeon, state.ShopItems, gState, state.CharacterState), appCmd_1];
    }
    else if (msg.tag === 2) {
        if (msg.fields[0][1].tag === 1) {
            const dungeon = msg.fields[0][1].fields[0];
            return [new State(state.Count, state.CurrentPage, dungeon, state.ShopItems, state.GameState, state.CharacterState), Cmd_none()];
        }
        else {
            const id = msg.fields[0][0] | 0;
            return [state, Cmd_OfAsyncWith_either((x_2) => {
                Cmd_OfAsync_start(x_2);
            }, getDungeon, id, (arg) => (new Msg_1(2, arg)), (arg_1) => (new Msg_1(6, arg_1)))];
        }
    }
    else if (msg.tag === 3) {
        if (msg.fields[0].tag === 1) {
            const items = msg.fields[0].fields[0];
            return [new State(state.Count, state.CurrentPage, state.Dungeon, items, state.GameState, state.CharacterState), Cmd_none()];
        }
        else {
            return [state, Cmd_OfAsyncWith_either((x_3) => {
                Cmd_OfAsync_start(x_3);
            }, getShopItems, void 0, (arg_3) => (new Msg_1(3, arg_3)), (arg_4) => (new Msg_1(6, arg_4)))];
        }
    }
    else if (msg.tag === 6) {
        const error = msg.fields[0];
        return [state, Cmd_none()];
    }
    else {
        const command = msg.fields[0][1];
        const page = msg.fields[0][0];
        return [new State(state.Count, page, state.Dungeon, state.ShopItems, state.GameState, state.CharacterState), singleton((dispatch) => {
            dispatch(command);
        })];
    }
}

export function render(state, dispatch) {
    const matchValue = state.CurrentPage;
    switch (matchValue.tag) {
        case 1: {
            return render_1(state.CharacterState, dispatch);
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
            return render_5(state.CharacterState, dispatch);
        }
        case 4: {
            return render_6(dispatch);
        }
        case 14: {
            return render_7(state, dispatch);
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
            return render_17(state, dispatch);
        }
        case 5: {
            return render_18(state, dispatch);
        }
        default: {
            return render_19(state.GameState, dispatch);
        }
    }
}

ProgramModule_run(Program_withReactSynchronous("elmish-app", ProgramModule_mkProgram(init, update, render)));

