import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import RequestState from "../types/AppStates/RequestState";
import Request from "../types/Api/Entities/Request";

const requestSlice = createSlice({
    name: "request",
    initialState: {
        ClientRequests: [],
        UserRequests: [],
        TypeRequests: []
    } as RequestState,
    reducers: {
        setClientRequests(state, action: PayloadAction<Request[]>) {
            state.ClientRequests = action.payload;
        },
        setUserRequests(state, action: PayloadAction<Request[]>) {
            state.UserRequests = action.payload;
        },
        setTypeRequests(state, action: PayloadAction<Request[]>) {
            state.TypeRequests = action.payload;
        },
        addRequest(state, action: PayloadAction<Request>) {
            state.ClientRequests.push(action.payload);
        },
        updateRequest(state, action: PayloadAction<Request>) {
            let clientRequest =
                state.ClientRequests.find(req => req.id === action.payload.id) as Request;
            if (clientRequest)
                clientRequest = action.payload;
            let userRequest =
                state.UserRequests.find(req => req.id === action.payload.id) as Request;

            if (userRequest)
                userRequest = action.payload;
            let typeRequests =
                state.TypeRequests.find(req => req.id === action.payload.id) as Request;
            if (typeRequests)
                typeRequests = action.payload;
        }
    },
});

export const {
    setClientRequests,
    setUserRequests,
    addRequest,
    updateRequest ,
    setTypeRequests
} = requestSlice.actions;
export default requestSlice.reducer;

