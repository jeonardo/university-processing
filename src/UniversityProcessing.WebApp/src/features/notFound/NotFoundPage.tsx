import { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

const NotFoundPage = () => {
  const nav = useNavigate();

  const [redirectionCountDown, setRedirectionCountDown] = useState<number>(5);

  const CountDown = () => {
    setRedirectionCountDown(redirectionCountDown - 1);
    if (redirectionCountDown == 0) {
      nav('/');
    }
  };

  useEffect(() => {
    setTimeout(() => CountDown(), 1000);
  });

  return (
    <div className="flex grow h-svh flex-col items-center justify-center bg-gray-100">
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