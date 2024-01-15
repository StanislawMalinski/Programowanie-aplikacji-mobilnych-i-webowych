import { useEffect, useState } from "react";
import Paginator from "../Paginator";
import PostList from "./PostList";
import { GetMaxPosts, GetPosts } from "../../Client";

function MainPage () {
    const [user, setUser] = useState(null);
    const [posts, setPosts] = useState([]);
    const [maxPages, setMaxPages] = useState(1);
    const [page, setPage] = useState(1);

    useEffect(() => {
        GetPosts(page).then((res) => {
            setPosts(res);
        }).catch((err) => {
            return (<></>);
        });

        GetMaxPosts().then((res) => { 
            setMaxPages(res);
        }).catch((err) => {
            return (<></>);
        });
    }, [page]);

    return (
        <div className="profile">
            <Paginator maxPages={maxPages} currentPage={page} setCurrentPage={setPage}/>
            <PostList posts={posts} navigateToUser={() => 1}/>
        </div>
    )
}

export default MainPage;