import { Image } from '@mui/icons-material';
import { useEffect, useState } from 'react';
import { Link, Navigate } from 'react-router-dom';
import { ENV } from '../../env';

const NotFoundPage = () => {
    const [redirectionCountDown, setRedirectionCountDown] = useState<number>(5);

    useEffect(() => {
        setTimeout(() => setRedirectionCountDown(redirectionCountDown - 1), 1000);
    });

    return (
        redirectionCountDown < 1
            ? <Navigate to="/" />
            : <div className="flex grow h-svh flex-col items-center justify-center bg-gray-100">
                <h1 className="text-4xl font-bold text-gray-800">404 - Page Not Found</h1>
                <p className="text-lg text-gray-600 mt-2">
                    Oops! The page you're looking for doesn't exist.
                </p>
                <Link to="/" className="text-blue-500 font-semibold mt-4 hover:underline">
                    Go back to the home page
                </Link>
                <p className="font-semibold">
                    auto redirect after {redirectionCountDown}...
                </p>
            </div>
    );
};

export default NotFoundPage;