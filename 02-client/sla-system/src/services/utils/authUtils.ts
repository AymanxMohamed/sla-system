


export const getUserData = () : string | null => {
    let localStorageUserData: string | null = localStorage.getItem("userData");
    let sessionStorageUserData: string | null = sessionStorage.getItem("userData");
    if (localStorageUserData)
        return JSON.stringify(localStorageUserData);
    else if (sessionStorageUserData)
        return JSON.stringify(sessionStorageUserData);
    return null;
}

export const getInitialState = () => {
    let user = getUserData();
}