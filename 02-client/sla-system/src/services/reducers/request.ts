import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import RequestState from "../types/AppStates/RequestState";
import Request from "../types/Api/Entities/Request";

const requestSlice = createSlice({
    name: "request",
    initialState: {
        ClientRequests: [],
        UserRequests: [],
    } as RequestState,
    reducers: {
        setClientRequests(state, action: PayloadAction<Request[]>) {
            state.ClientRequests = action.payload;
        },
        setUserRequests(state, action: PayloadAction<Request[]>) {
            state.UserRequests = action.payload;
        }
    },
});

export const { setClientRequests, setUserRequests  } = requestSlice.actions;
export default requestSlice.reducer;

