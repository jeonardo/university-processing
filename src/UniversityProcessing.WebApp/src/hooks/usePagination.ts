import { useEffect, useState } from 'react';
import { useSearchParams } from 'react-router-dom';

export const usePagination = (pageSize: number = 25) => {
  const [searchParams, setSearchParams] = useSearchParams();
  const [page, setPage] = useState(1);

  const pageParamString = searchParams.get('page')
  const pageParam = pageParamString ? parseInt(pageParamString) : 1;

  const resetPage = () => setPage(1);

  const changePage = (newPage: number) => {
    const newSearchParams = new URLSearchParams(searchParams);
    newSearchParams.set('page', newPage.toString());
    setSearchParams(newSearchParams);
  };

  useEffect(() => {
    setPage(pageParam)
  }, [pageParam]);

  return { page, pageSize, changePage, resetPage };
}