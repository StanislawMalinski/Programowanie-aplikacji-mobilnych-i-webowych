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
            console.error(err);
            return (<></>);
        });

        GetMaxPosts().then((res) => { 
            setMaxPages(res);
        }).catch((err) => {
            console.error(err);
            return (<></>);
        });
        console.log(page);
    }, [page]);

    return (
        <div className="profile">
            <p>Dzień dobry</p>
            <PostList posts={posts} navigateToUser={() => 1}/>
            <Paginator maxPages={maxPages} currentPage={page} setCurrentPage={setPage}/>
        </div>
    )
}

export default MainPage;