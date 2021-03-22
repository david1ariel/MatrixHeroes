import { environment } from 'src/environments/environment';
import { AppState } from './app-state';
import { Action } from './action';
import { ActionType } from './action-type';
import { Notyf } from 'notyf';



const notify = new Notyf();

export function reducer(currentState: AppState, action: Action): AppState {

  const newState = { ...currentState }; // Spread Operator

  switch (action.type) {

    case ActionType.Register:
    case ActionType.Login: {
      newState.trainer = action.payload;
      if (newState.trainer)
        sessionStorage.setItem("trainer", JSON.stringify(newState.trainer));
      break;
    }

    case ActionType.Logout: {
      newState.trainer = null;
      sessionStorage.removeItem("trainer");
      newState.heroes = [];
      break;
    }

    case ActionType.GetAllHeroesByTrainerId: {
      newState.heroes = action.payload;
      break;
    }

    case ActionType.AddHero: {
      newState.heroes.push(action.payload);
      break;
    }

    case ActionType.DeleteHero: {
      const index = newState.heroes.findIndex(p => p.HeroId === action.payload);
      newState.heroes.splice(index, 1);
      break;
    }


  }

  return newState;
}

function getErrorMessage(errorObject) {
  console.log(errorObject);
  if (typeof errorObject.error === "string") {
    return errorObject.error;
  }

  if (errorObject.status === 401 || errorObject.status === 403) {
    return "You are not authorized";
  }

  if (errorObject.status === 400) {
    return "Incorrect input,<br> please try again";
  }

  return "Some error occurred, please try again later";
}
