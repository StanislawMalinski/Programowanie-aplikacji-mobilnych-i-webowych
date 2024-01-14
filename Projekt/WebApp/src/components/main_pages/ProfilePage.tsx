import { getUser } from "../../User";
import { GetUser, GetMaxPostsForUser, GetPostsForUser } from "../../Client";
import { useEffect, useState } from "react";
import Paginator from "../Paginator";

import PostList from "./PostList";
import UserProfile from "./UserProfile";

function ProfilePage() {
    const [user, setUser] = useState(null);
    const [posts, setPosts] = useState([]);
    const [maxPages, setMaxPages] = useState(1);
    const [page, setPage] = useState(1);

    var loc = getUser();
    if (loc === null) return (<></>);
    const locj = JSON.parse(loc);
    setUser(locj);
    if (locj === undefined || locj.id === undefined) return (<></>);

    useEffect(() => {
        GetUser(locj.id).then((res) => {
            setUser(res);
        }).catch((err) => {
            console.error(err);
            return (<></>);
        });

        GetPostsForUser(locj.id, 1).then((res) => {
            setPosts(res);
        }).catch((err) => {
            console.error(err);
            return (<></>);
        });

        GetMaxPostsForUser(locj.id).then((res) => { 
            setMaxPages(res);
        }).catch((err) => {
            console.error(err);
            return (<></>);
        });
    }, []);

    return (<>
        <div className="profile">
            <UserProfile user={user} />
            <PostList posts={posts} navigateToUser={() => 1}/>
            <Paginator maxPages={maxPages} currentPage={page} setCurrentPage={setPage}/>
        </div>
    </>);
}

export default ProfilePage;