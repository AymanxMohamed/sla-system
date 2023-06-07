import {Navigate, Route, Routes, useLocation} from "react-router-dom";
import PageNotFoundView from "../views/pages/errors/views/PageNotFoundView";


const AppRoutes: React.FC = (): JSX.Element => {
    const location = useLocation();
    return(
        <Routes>
            <Route path="404" element={<PageNotFoundView /> }/>
            <Route
                path="*"
                element={ <Navigate to={"404"} state={{ from: location }} replace /> }
            >
            </Route>
        </Routes>
    )
}
export default AppRoutes;