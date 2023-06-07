import User from "../types/Api/Entities/User";
import AuthState from "../types/AppStates/AuthState";


export const getUserData = () : User | undefined => {
    let localStorageUserData: string | null = localStorage.getItem("userData");
    let sessionStorageUserData: string | null = sessionStorage.getItem("userData");
    if (localStorageUserData)
        return JSON.parse(localStorageUserData);
    else if (sessionStorageUserData)
        return JSON.parse(sessionStorageUserData);
    return;
}

export const getInitialState = (): AuthState => {
    let user: User | undefined = getUserData();
    return { user: user}
}

export const updateStorageUserData = (userData: User) => {
    let localStorageUserData: string | null = localStorage.getItem("userData");
    if (localStorageUserData) {
        localStorage.setItem("userData", JSON.stringify(userData));
    } else {
        sessionStorage.setItem("userData", JSON.stringify(userData));
    }
}

export const removeStorageUserData = () => {
    localStorage.removeItem("userData");
    sessionStorage.removeItem("userData");
}