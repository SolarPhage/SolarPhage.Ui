import * as main from "./scss/main.scss";
import { singleton } from "./fable_modules/fable-library.3.7.20/AsyncBuilder.js";
import { Http_get } from "./fable_modules/Fable.SimpleHttp.3.5.0/Http.fs.js";
import { Msg, Model, Page } from "./Types.fs.js";
import { Cmd_none } from "./fable_modules/Fable.Elmish.3.1.0/cmd.fs.js";
import { Cmd_OfAsync_start, Cmd_OfAsyncWith_either } from "./fable_modules/Fable.Elmish.3.1.0/./cmd.fs.js";
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
import { ProgramModule_mkProgram, ProgramModule_run } from "./fable_modules/Fable.Elmish.3.1.0/program.fs.js";
import { Program_withReactSynchronous } from "./fable_modules/Fable.Elmish.React.3.0.1/react.fs.js";


export const gamesUrl = (process.env.APIURL) + "/game";

export function x(y) {
    return singleton.Delay(() => singleton.Bind(Http_get(gamesUrl), (_arg) => {
        const statusCode = _arg[0] | 0;
        const responseText = _arg[1];
        return singleton.Return(responseText);
    }));
}

export function init() {
    return [new Model(0, new Page(0)), Cmd_none()];
}

export function update(msg, state) {
    switch (msg.tag) {
        case 1: {
            const y = msg.fields[0];
            return [new Model(state.Count - 1, state.CurrentPage), Cmd_none()];
        }
        case 2: {
            const page = msg.fields[0];
            return [new Model(state.Count, page), Cmd_OfAsyncWith_either((x_2) => {
                Cmd_OfAsync_start(x_2);
            }, x, "test", (arg) => (new Msg(0, arg)), (arg_1) => (new Msg(1, arg_1)))];
        }
        default: {
            const x_1 = msg.fields[0];
            return [new Model(state.Count + 1, state.CurrentPage), Cmd_none()];
        }
    }
}

export function render(state, dispatch) {
    const matchValue = state.CurrentPage;
    switch (matchValue.tag) {
        case 1: {
            return render_1(dispatch);
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
            return render_13(dispatch);
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
            return render_19(dispatch);
        }
    }
}

ProgramModule_run(Program_withReactSynchronous("elmish-app", ProgramModule_mkProgram(init, update, render)));

