import { combineReducers } from "@reduxjs/toolkit";
import authReducer from "../services/reducers/auth";
import queueReducer from "../services/reducers/queue";
import requestReducer from "../services/reducers/request";
import slaReducer from "../services/reducers/sla";
import userReducer from "../services/reducers/user";

const rootReducer = combineReducers({
    auth: authReducer,
    queue: queueReducer,
    request: requestReducer,
    sla: slaReducer,
    user: userReducer,
});

export type RootState = ReturnType<typeof rootReducer>;

export default rootReducer;
